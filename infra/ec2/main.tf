provider "aws" {
  region = local.region
}

locals {
  region = "ap-southeast-2"
  key_name = "school"
  env = "school"
  public_key_path = "~/.ssh/id_ed25519.pub"

  vpc_security_group_ids=["sg-0a4693cdb0b3b7483"]
  subnet_id="subnet-0d0092b39768fba07"

  ami = "ami-023dd49682f8a7c2b"
  instance_type = "t2.small"
  create_cname = true
  zone_name = "school.au"
  cname = "school.au.com"
}

resource "aws_key_pair" "this" {
  key_name        = local.key_name
  public_key      = file(local.public_key_path)

  tags = {
    env = local.env
  }
}


module "ec2_instance" {
  source  = "git::https://github.com/terraform-aws-modules/terraform-aws-ec2-instance.git?ref=v4.3.0"
  name = "single-instance"
  ami                    = local.ami
  instance_type          = local.instance_type
  key_name               = local.key_name
  monitoring             = true
  vpc_security_group_ids = local.vpc_security_group_ids
  subnet_id              = local.subnet_id
  associate_public_ip_address = true

  tags = {
    Terraform   = "true"
    Environment = "dev"
  }
}

data "aws_route53_zone" "default" {
  name         = local.zone_name
  private_zone = false
}

resource "aws_route53_record" "bastion" {
  count = local.create_cname ? 1 : 0

  zone_id         = data.aws_route53_zone.default.zone_id
  name            = local.cname
  type            = "A"
  ttl             = "300"
  records         = [module.ec2_instance.public_ip]
  allow_overwrite = true
}

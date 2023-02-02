provider "aws" {
  region = local.region
}

locals {
  region = "ap-southeast-2"
}

resource "aws_ecr_repository" "school_ecr" {
  name = "school-ecr"
}

output "ecr_repository_url" {
  value = aws_ecr_repository.school_ecr.repository_url
}

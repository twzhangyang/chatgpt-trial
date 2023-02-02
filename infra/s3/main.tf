provider "aws" {
  region = "ap-southeast-2"
}

resource "aws_s3_bucket" "chatgpt_trial_bucket_name" {
  bucket = "chatgpt-trial-bucket-name"
}

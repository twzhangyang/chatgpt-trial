#!/bin/bash

# Set the name of the zip file
zip_file="schoolApp.zip"

# Set the name of the S3 bucket
bucket_name="chatgpt-trial-bucket-name"

# Set the path to the zip file in the S3 bucket
s3_path="s3://$bucket_name/$zip_file"

# Upload the zip file to the S3 bucket
aws s3 cp $zip_file $s3_path

# Print a message indicating that the zip file has been uploaded successfully
echo "$zip_file has been uploaded successfully to $s3_path."

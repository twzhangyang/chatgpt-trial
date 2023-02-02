#!/bin/bash

# Set the name of the application
app_name="schoolApp"

# Set the path to the .NET Core application
app_path="../bin/debug/net6.0"

# Create a temporary directory for the zip file
zip_dir="$(mktemp -d)/$app_name"

# Copy the application files to the temporary directory
cp -r $app_path $zip_dir

# Create the zip file
zip -r "$app_name.zip" $zip_dir

# Remove the temporary directory
rm -rf $zip_dir

# Print a message indicating that the application has been packaged successfully
echo "$app_name has been packaged successfully as a zip file."

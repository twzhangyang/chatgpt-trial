export class StudentValidator {
  static validate(student: Student) {
    const errors: { [key: string]: string } = {}

    // add validation code here
    if (!student.firstName) {
      errors.firstName = "First Name is required"
    }

    if (student.lastName.length > 20) {
      errors.lastName = "Last Name should not exceed 20 characters"
    }

    const emailRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/
    if (!student.email) {
      errors.email = "Email is required"
    } else if (!emailRegex.test(student.email)) {
      errors.email = "Invalid Email address"
    }

    if (!student.hobbies.length) {
      errors.hobbies = "Please provide at least one hobby"
    }

    return errors
  }
}

export class Student {
  constructor(
    public firstName: string,
    public lastName: string,
    public email: string,
    public age: number,
    public className: string,
    public schoolName: string,
    public favoriteFood: string[],
    public hobbies: string[]
  ) {
  }
}



// tests/student-validator.test.ts
import { StudentValidator } from './StudentValidator';

describe('StudentValidator', () => {
  it('should return an error when First name is empty', () => {
    const student = {
      firstName: '',
      lastName: 'Smith',
      email: 'john.smith@example.com',
      age: 18,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: ['Reading', 'Swimming'],
    };

    expect(StudentValidator.validate(student)).toEqual({
      firstName: 'First Name is required',
    });
  });

  it('should return an error when the length of the Last name is greater than 20', () => {
    const student = {
      firstName: 'John',
      lastName: 'A very long last name that exceeds 20 characters',
      email: 'john.smith@example.com',
      age: 18,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: ['Reading', 'Swimming'],
    };

    expect(StudentValidator.validate(student)).toEqual({
      lastName: 'Last Name should not exceed 20 characters',
    });
  });

  it('should return an error when Email is empty or a wrong format', () => {
    const student = {
      firstName: 'John',
      lastName: 'Smith',
      email: '',
      age: 18,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: ['Reading', 'Swimming'],
    };

    expect(StudentValidator.validate(student)).toEqual({
      email: 'Email is required',
    });

    student.email = 'invalid.email';
    expect(StudentValidator.validate(student)).toEqual({
      email: 'Invalid Email address',
    });
  });

  it('should return an error when Hobbies is empty', () => {
    const student = {
      firstName: 'John',
      lastName: 'Smith',
      email: 'john.smith@example.com',
      age: 18,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: [],
    };

    expect(StudentValidator.validate(student)).toEqual({
      hobbies: 'Please provide at least one hobby',
    });
  });

  it('should return no errors when all information is correct', () => {
    const student = {
      firstName: 'John',
      lastName: 'Smith',
      email: 'john.smith@example.com',
      age: 18,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: ['Reading', 'Swimming'],
    };

    expect(StudentValidator.validate(student)).toEqual({});
  });
});

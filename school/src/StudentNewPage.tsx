import React, { useState } from 'react';
import { Table, Form, FormControl, Button, Container, Row, Col, FormGroup, FormText } from "react-bootstrap"

interface StudentNew {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
  email: string;
  enrollmentDate: string;
}

const mockData = [
  {
    id: 1,
    firstName: 'John',
    lastName: 'Doe',
    age: 25,
    email: 'johndoe@email.com',
    enrollmentDate: '2022-01-01'
  },
  {
    id: 2,
    firstName: 'Jane',
    lastName: 'Doe',
    age: 30,
    email: 'janedoe@email.com',
    enrollmentDate: '2022-02-01'
  },
  {
    id: 3,
    firstName: 'Jim',
    lastName: 'Smith',
    age: 28,
    email: 'jimsmith@email.com',
    enrollmentDate: '2022-03-01'
  },
  {
    id: 4,
    firstName: 'Amy',
    lastName: 'Johnson',
    age: 27,
    email: 'amyjohnson@email.com',
    enrollmentDate: '2022-04-01'
  },
  {
    id: 5,
    firstName: 'Tom',
    lastName: 'Williams',
    age: 26,
    email: 'tomwilliams@email.com',
    enrollmentDate: '2022-05-01'
  },
  {
    id: 6,
    firstName: 'Maggie',
    lastName: 'Brown',
    age: 24,
    email: 'maggiebrown@email.com',
    enrollmentDate: '2022-06-01'
  },
  {
    id: 7,
    firstName: 'Tim',
    lastName: 'Davis',
    age: 29,
    email: 'timdavis@email.com',
    enrollmentDate: '2022-07-01'
  },
  {
    id: 8,
    firstName: 'Emma',
    lastName: 'Jones',
    age: 33,
    email: 'emmajones@email.com',
    enrollmentDate: '2022-08-01'
  },
  {
    id: 9,
    firstName: 'Michael',
    lastName: 'Miller',
    age: 31,
    email: 'michaelmiller@email.com',
    enrollmentDate: '2022-09-01'
  },
  {
    id: 10,
    firstName: 'Emily',
    lastName: 'Wilson',
    age: 35,
    email: 'emilywilson@email.com',
    enrollmentDate: '2022-10-01'
  },
  {
    id: 11,
    firstName: 'Matthew',
    lastName: 'Anderson',
    age: 32,
    email: 'matthewanderson@email.com',
    enrollmentDate: '2022-11-01'
  },
  {
    id: 12,
    firstName: 'Olivia',
    lastName: 'Taylor',
    age: 28,
    email: 'oliviataylor@email.com',
    enrollmentDate: '2022-12-01'
  }
];

function StudentNew() {
  const [students, setStudents] = useState(mockData);
  const [loading, setLoading] = useState(false);

  return (
    <Container>
      <Form className="d-flex mb-6">
        <FormGroup className="mr-6">
          <Form.Label for="search">Search:</Form.Label>
          <FormControl type="text" placeholder="Search" className="mr-sm-2" />
        </FormGroup>
        <Button color="primary">Search</Button>
      </Form>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <Table responsive>
          <thead>
          <tr>
            <th>ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Age</th>
            <th>Email</th>
            <th>Enrollment Date</th>
            <th>Actions</th>
          </tr>
          </thead>
          <tbody>
          {students.map(student => (
            <tr key={student.id}>
              <td>{student.id}</td>
              <td>{student.firstName}</td>
              <td>{student.lastName}</td>
              <td>{student.age}</td>
              <td>{student.email}</td>
              <td>{student.enrollmentDate}</td>
              <td>
                <Button color="primary" size="sm">
                  Update
                </Button>{' '}
                <Button color="secondary" size="sm">
                  Details
                </Button>{' '}
                <Button color="danger" size="sm">
                  Delete
                </Button>
              </td>
            </tr>
          ))}
          </tbody>
        </Table>
      )}
    </Container>
  );
}

export default StudentNew;

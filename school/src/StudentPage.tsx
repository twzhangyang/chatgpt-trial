import React, { useState } from 'react';
import { Table, Form, FormControl, Button, Container, Row, Col } from 'react-bootstrap';

interface Student {
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

function Student() {
  const [students, setStudents] = useState(mockData);

  return (
    <Container>
      <Row>
        <Col xs={3}>
          <Form>
            <FormControl type="text" placeholder="Search" className="mr-sm-2" />
            <Button variant="outline-primary">Search</Button>
          </Form>
        </Col>
        <Col xs={6}>
          <Table striped bordered hover>
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
                  <Button variant="primary" size="sm">Update</Button>{' '}
                  <Button variant="secondary" size="sm">Details</Button>{' '}
                  <Button variant="danger" size="sm">Delete</Button>
                </td>
              </tr>
            ))}
            </tbody>
          </Table>
        </Col>
        <Col xs={3}>
          <img src="https://via.placeholder.com/300x300.png?text=Cat" alt="Cat" />
        </Col>
      </Row>
    </Container>
  );
}

export default Student;

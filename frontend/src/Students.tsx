import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";

interface Student {
  id: number;
  lastName: string;
  firstName: string;
  enrollmentDate: string;
  email: string;
  age: number;
}

const mockData = [
  {
    id: 1,
    lastName: 'Smith',
    firstName: 'John',
    enrollmentDate: '2020-01-01',
    email: 'john.smith@example.com',
    age: 25
  },
  {
    id: 2,
    lastName: 'Doe',
    firstName: 'Jane',
    enrollmentDate: '2020-02-01',
    email: 'jane.doe@example.com',
    age: 28
  },
  {
    id: 3,
    lastName: 'Johnson',
    firstName: 'Michael',
    enrollmentDate: '2020-03-01',
    email: 'michael.johnson@example.com',
    age: 30
  }
];

export const StudentList: React.FC = () => {
  const [students, setStudents] = useState<Student[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      // const response = await fetch("https://api.example.com/students");
      // const data = await response.json();
      const data = mockData;
      setStudents(data);
    };
    fetchData();
  }, []);

  return (
    <Table striped bordered hover>
      <thead>
      <tr>
        <th>Id</th>
        <th>LastName</th>
        <th>FirstName</th>
        <th>EnrollmentDate</th>
        <th>Email</th>
        <th>Age</th>
      </tr>
      </thead>
      <tbody>
      {students.map((student) => (
        <tr key={student.id}>
          <td>{student.id}</td>
          <td>{student.lastName}</td>
          <td>{student.firstName}</td>
          <td>{student.enrollmentDate}</td>
          <td>{student.email}</td>
          <td>{student.age}</td>
        </tr>
      ))}
      </tbody>
    </Table>
  );
};

export default StudentList;

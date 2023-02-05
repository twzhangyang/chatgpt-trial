import React, { useState } from "react"
import { Form, FormGroup, Button, Alert } from "react-bootstrap"

const AddStudent = () => {
  const [firstName, setFirstName] = useState("")
  const [lastName, setLastName] = useState("")
  const [age, setAge] = useState("")
  const [enrollmentDate, setEnrollmentDate] = useState("")
  const [email, setEmail] = useState("")
  const [errors, setErrors] = useState({})
  const [success, setSuccess] = useState(false)

  const handleSubmit = e => {
    e.preventDefault()
    let err = {}
    setErrors(err)
    setSuccess(false)

    if (Object.keys(err).length === 0) {
      // send data to API
      setSuccess(true)
    }
  }

  return (
    <Form onSubmit={handleSubmit}>
      {Object.keys(errors).length > 0 && (
        <Alert color="danger">
          {Object.values(errors).map(error => (
            <div key={error}>{error}</div>
          ))}
        </Alert>
      )}
      {success && (
        <Alert color="success">
          Student information added successfully.
        </Alert>
      )}
      <FormGroup>
        <Label for="firstName">First Name</Label>
        <Input
          type="text"
          id="firstName"
          value={firstName}
          onChange={e => setFirstName(e.target.value)}
        />
      </FormGroup>
      <FormGroup>
        <Label for="lastName">Last Name</Label>
        <Input
          type="text"
          id="lastName"
          value={lastName}
          onChange={(e: { target: { value: React.SetStateAction<string> } }) => setLastName(e.target.value)}
        />
      </FormGroup>
      <FormGroup>
        <Label for="age">Age</Label>
        <Input
          type="number"
          id="age"
          value={age}
          onChange={(e: { target: { value: React.SetStateAction<string> } }) => setAge(e.target.value)}
        />
      </FormGroup>
      <FormGroup>
        <Label for="enrollmentDate">Enrollment Date</Label>
        <Input
          type="date"
          id="enrollmentDate"
          value={enrollmentDate}
        />
      </FormGroup>
    </Form>
  );
}

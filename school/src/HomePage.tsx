import React from 'react';
import { Container, Card, Button } from 'react-bootstrap';

const HomePage = () => {
  return (
    <Container className="my-5">
      <Card>
        <Card.Header>
          <h1 className="text-center">Welcome to My CMS</h1>
        </Card.Header>
        <Card.Body>
          <p className="lead">This is a simple and easy-to-use CMS for managing student information and enrollments.</p>
          <hr className="my-4" />
          <p>It offers a range of features, including student information management, enrollment management, reporting, and user management.</p>
          <p className="text-center">
            <Button className="primary">Learn More</Button>
          </p>
        </Card.Body>
      </Card>
    </Container>
  );
};

export default HomePage;

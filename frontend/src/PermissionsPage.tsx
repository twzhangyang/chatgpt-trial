import React, { useState } from 'react';
import { Form, FormGroup, Container, Row, Col, Button } from 'react-bootstrap';

export interface Permission {
  read: boolean;
  write: boolean;
  delete: boolean;
}

interface Props {
  onSubmit: (permissions: Permission[]) => void;
}

const PermissionCheckboxes: React.FC<Props> = ({ onSubmit }) => {
  const [rows, setRows] = useState<Permission[]>([
    { read: false, write: false, delete: false },
    { read: false, write: false, delete: false },
    { read: false, write: false, delete: false },
    { read: false, write: false, delete: false },
  ]);

  const handleChange = (rowIndex: number, name: keyof Permission) => (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const newRows = [...rows];
    newRows[rowIndex][name] = event.target.checked;

    if (name === 'delete') {
      newRows[rowIndex].read = event.target.checked;
      newRows[rowIndex].write = event.target.checked;
    } else if (!newRows[rowIndex].read || !newRows[rowIndex].write) {
      newRows[rowIndex].delete = false;
    }

    setRows(newRows);
  };

  const handleSubmit = () => {
    const permissions = rows.map((row) => ({
      read: row.read,
      write: row.write,
      delete: row.delete,
    }));

    onSubmit(permissions);
  };

  return (
    <Container>
      <Form>
        {rows.map((row, index) => (
          <Row key={index}>
            <Col>
              <FormGroup>
                <Form.Label>
                  <Form.Check
                    type="checkbox"
                    checked={row.read}
                    onChange={handleChange(index, 'read')}
                  />
                  Read
                </Form.Label>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Form.Label>
                  <Form.Check
                    type="checkbox"
                    checked={row.write}
                    onChange={handleChange(index, 'write')}
                  />
                  Write
                </Form.Label>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Form.Label>
                  <Form.Check
                    type="checkbox"
                    checked={row.delete}
                    onChange={handleChange(index, 'delete')}
                  />
                  Delete
                </Form.Label>
              </FormGroup>
            </Col>
          </Row>
        ))}
        <Button onClick={handleSubmit}>Submit</Button>
      </Form>
    </Container>
  );
};

export default PermissionCheckboxes;

import axios from 'axios';
import { StudentClient } from './StudentClient';
import * as nock from "nock"

describe('StudentClient', () => {
  it('should post student data', async () => {
    const studentData = {
      firstName: 'John',
      lastName: 'Doe',
      email: 'john.doe@example.com',
      age: 25,
      className: 'Class 1',
      schoolName: 'School 1',
      favoriteFood: ['Pizza', 'Hamburger'],
      hobbies: ['Reading', 'Swimming']
    };

    const mockResponseData = { message: 'Student data posted successfully' };

    nock('https://your-backend-api.com')
      .post('/students', studentData)
      .reply(200, mockResponseData);

    const studentClient = new StudentClient();
    const response = await studentClient.postStudentData(studentData);

    expect(response).toEqual(mockResponseData);
  });
});

import axios from 'axios';

export class StudentClient {
  async postStudentData(studentData: any) {
    try {
      const response = await axios.post('https://your-backend-api.com/students', studentData);
      return response.data;
    } catch (error) {
      console.error(error);
      return error;
    }
  }
}

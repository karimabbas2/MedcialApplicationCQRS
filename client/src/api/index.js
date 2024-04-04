import axios from 'axios'
const API = axios.create({ baseURL: 'http://localhost:5155/api' });

//Departments
export const GetAllDepts = () => API.get('/Department');
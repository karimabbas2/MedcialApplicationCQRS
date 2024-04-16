import axios from 'axios'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
const API = axios.create({ baseURL: 'http://localhost:5155/api' });

const MySwal = withReactContent(Swal)


//Departments
export const GetAllDepts = () => API.get('/Department');
export const PostDept = (newDept) => API.post('/Department', newDept);
export const DeleteDept = (id) => API.delete(`/Department/${id}`);
export const UpdateDept = (dept) => API.put('/Department', dept);

//Doctors 
export const GetAllDoctors = () => API.get('/Doctor');
export const PostDoctor = (newDoctor) => API.post('/Doctor', newDoctor);
export const DeleteDoctor = (id) => API.delete(`/Doctor/${id}`);
export const UpdateDoctor = (doctor) => API.put('/Doctor', doctor);

//Appoinmtnets
export const GetAllAppointments = () => API.get('/Appointment');
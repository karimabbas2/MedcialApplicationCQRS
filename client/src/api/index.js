import axios from 'axios'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
const API = axios.create({ baseURL: 'http://localhost:5155/api' });

const MySwal = withReactContent(Swal)

API.interceptors.request.use((req) => {
    if (localStorage.getItem('UserToken')) {
        req.headers.authorization = `Bearer ${localStorage.getItem('UserToken')}`;
    }
    return req;
},
    error => Promise.reject(error)
)

API.interceptors.response.use(res => res, error => {
    if (error.response.status === 403) {
        MySwal.fire({
            title: 'Not Allowed !!',
            text: "You Not Authorized to this action!",
            icon: 'warning',
            confirmButtonText: 'okay!',

            customClass: {
                confirmButton: 'btn btn-warning',
            }
        });
        return Promise.reject({ status: 403, errors: ['Unauthorized'] })
    }
})


// Sign In // Sign Up 
export const Register = (data) => API.post('/Auth/Register', data);
export const LogIn = (data) => API.post('/Auth/Login', data);


//Departmentss
export const GetAllDepts = () => API.get('/Department');
export const PostDept = (newDept) => API.post('/Department', newDept);
export const DeleteDept = (id) => API.delete(`/Department/${id}`);
export const UpdateDept = (dept) => API.put('/Department', dept);
export const GetDept = (id) => API.get(`/Department/${id}`);

//Doctors 
export const GetAllDoctors = () => API.get('/Doctor');
export const PostDoctor = (newDoctor) => API.post('/Doctor', newDoctor);
export const DeleteDoctor = (id) => API.delete(`/Doctor/${id}`);
export const UpdateDoctor = (doctor) => API.put('/Doctor', doctor);

//Appoinmtnets
export const GetAllAppointments = () => API.get('/Appointment');
export const PostAppointment = (newAppointment) => API.post('/Appointment', newAppointment);
export const DeleteAppointment = (id) => API.delete(`/Appointment/${id}`);
export const UpdateAppointment = (appointment) => API.put('/Appointment', appointment);
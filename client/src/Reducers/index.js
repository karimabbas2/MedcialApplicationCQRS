import { combineReducers } from "redux";
import DepartmentsStore from "../Components/Department/store/reducer";
import DoctorsStore from "../Components/Doctor/store/reducer";
import AppointmentStore from "../Components/Appointment/store/reducer";

export const reducers = combineReducers({ DepartmentsStore,DoctorsStore,AppointmentStore });
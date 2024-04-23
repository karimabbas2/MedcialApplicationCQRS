import { combineReducers } from "redux";
import DepartmentsStore from "../Components/Department/store/reducer";
import DoctorsStore from "../Components/Doctor/store/reducer";
import AppointmentStore from "../Components/Appointment/store/reducer";
import FrontPageStore from "../Components/FrontPage/Store/reducer";
import AuthStore from "../Components/Authentication/store/reducer";

export const reducers = combineReducers({ DepartmentsStore,DoctorsStore,AppointmentStore,FrontPageStore,AuthStore });
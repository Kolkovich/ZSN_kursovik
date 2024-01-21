import {user_model} from "./user.ts";

const currentUser : user_model = new user_model(2, "", "", "", "");
export default currentUser;

export function clearCurrentUser(){
    currentUser.id = 0;
    currentUser.phone = "";
    currentUser.password = "";
    currentUser.role = "";
    currentUser.organization = "";
}
export function setCurrentUser(user : user_model){
    currentUser.id = user.id;
    currentUser.phone = user.phone;
    currentUser.password = user.password;
    currentUser.role = user.role;
    currentUser.organization = user.organization;
}

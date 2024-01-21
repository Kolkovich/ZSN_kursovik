import React from "react";
import axios from "axios";
import {setCurrentUser} from "./reg_log.ts";
export class user_model{
    constructor(
        public id : number, 
        public role : string,
        public phone : string,
        public organization : string,
        public password : string){}
}

export function get_user(id : number = 0) {
    const [helper , setUser] = React.useState<user_model>();
    let url : string;
    if (id == 0){
        url = 'api/get_user';
    } else {
        url = 'api/get_user?id=' + id;
    }
    axios.get<user_model>(url, {
        baseURL : '',
    }).then( response => {
        setUser(response.data);
    })
    
    return helper;
}

export function find_user(password : string,  phone : string, organisation : string = ""){
    const [helper , setUser] = React.useState<user_model>();
    let url :string = "";
    if (organisation == ""){
        url = 'api/get_user?phone=' + phone + "&password=" + password;
    } else {
        url = 'api/get_user?organisation=' + organisation + "&phone=" + phone + "&password=" + password;
    }
    axios.get<user_model>(url, {
        baseURL : '',
    }).then( response => {
        if(response.data)
            setUser(response.data);
        else 
            throw Error(
                "User not found. His credentials: \norganisation: "
                + organisation
                + "\npassword: "
                + password
                + "\nphone: "
                + phone);
    })

    return helper;
}


export function check_user(password : string,  phone : string){
    const [helper , setUser] = React.useState<user_model>();
    let url : string = 'api/get_user?password=' + password + "&phone=" + phone;
    axios.get<user_model>(url, {
        baseURL : '',
    }).then( response => {
        if(response.data)
            setUser(response.data);
    })
    return helper != undefined;
}

export function add_user(organisation : string,  phone : string, password : string){
    let last_id : number | undefined = get_last_id();
    let url : string;
    if (last_id == undefined){
        url ='api/add_user?id=1' + "&organisation=" + organisation + "&phone=" + phone + "&password" + password + "&role=admin"
    } else {
        last_id += 1;
    }
    url = 'api/add_user?id=' + last_id + "&organisation=" + organisation + "&phone=" + phone + "&password" + password + "&role=user";
    axios.get<user_model>(url, {
        baseURL : '',
    }).then( response => {
        if(response.data)
            setCurrentUser(response.data);
    })
}

function get_last_id() : number | undefined{
    const [helper , setUser] = React.useState<number>();
    let url : string = 'api/get_last_id';
    axios.get<number>(url, {
        baseURL : '',
    }).then( response => {
        if(response.data)
            setUser(response.data);
    })

    return helper;
}
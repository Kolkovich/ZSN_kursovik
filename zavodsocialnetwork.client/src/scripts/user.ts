import React from "react";
import axios from "axios";
export class user_model{
    
    
    constructor(
        public id : number, 
        public role : string,
        public phone : string,
        public organization : string,
        public password : string){}
}

export default function get_user(id : number = 0) {
    const [helper , setUser] = React.useState<user_model>();
    let url : string;
    if (id == 0){
        url = 'enter/';
    } else {
        url = 'enter/' + id;
    }
    axios.get<user_model>(url, {
        baseURL : '',
    }).then( response => {
        setUser(response.data);
    })
    
    return helper;
}
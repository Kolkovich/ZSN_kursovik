/*
import React from "react";
import axios from "axios";
*/

export class Contract
{
    public id : number = 0;
    public executor : string | undefined = "";
    public receiver : string | undefined = "";
    public product : Product = new Product();
    public quantity : string = "";
    public m_status : string = "";
    public exconditions : string = "";
    public receipt : Receipt = new Receipt();
    public regularity : string = "";
    constructor
    (id : number,
     product : Product,
     quantity : string,
     m_status : string,
     exconditions: string,
     receipt : Receipt,
     regularity : string)
    {
        this.id = id;
        this.product = product;
        this.quantity  = quantity;
        this.m_status  = m_status;
        this.exconditions = exconditions;
        this.receipt = receipt;
        this.regularity = regularity;
    }
}

export class Product {
    public id : number = 0;
    public description : string = "";
    constructor
    (id : number,
    description : string)
    {
        this.id = id;
        this.description = description;
    }
}

export class Receipt {
    public id: number = 0;
    public totalPayment: number = 0;
    public expenses: number = 0;
    public ourShare: number = 0.07;
    constructor
    (id : number,
     totalPayment : number)
    {
        this.id = id;
        this.totalPayment = totalPayment;
    }
}


/*export function get_all_contracts(){
    
}*/
/*
export function get_contract(id : number = 0) {
    const [helper , setUser] = React.useState<Contract>();
    let url : string;
    if (id == 0){
        url = 'api/get_contract';
    } else {
        url = 'api/get_contract?id=' + id;
    }
    axios.get<Contract>(url, {
        baseURL : '',
    }).then( response => {
        setUser(response.data);
    })

    return helper;
}

export function find_contract(password : string,  phone : string, organisation : string = ""){
    const [helper , setUser] = React.useState<Contract>();
    let url :string = "";
    if (organisation == ""){
        url = 'api/get_contract?phone=' + phone + "&password=" + password;
    } else {
        url = 'api/get_contract?organisation=' + organisation + "&phone=" + phone + "&password=" + password;
    }
    axios.get<Contract>(url, {
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


export function add_contract(organisation : string,  phone : string, password : string){
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

export function get_product(id : number = 0) {
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

export function find_product(password : string,  phone : string, organisation : string = ""){
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


export function check_product(password : string,  phone : string){
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

export function add_product(organisation : string,  phone : string, password : string){
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

//При создании чека указывается лишь TotalPayment, остальное вычисляется.
export function get_receipt(id : number = 0) {
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

export function find_receipt(password : string,  phone : string, organisation : string = ""){
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


export function check_receipt(password : string,  phone : string){
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

export function add_receipt(organisation : string,  phone : string, password : string){
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
*/



//import { useEffect, useState } from 'react';
import '../scss/Header.scss';
import './RegLoginButton.tsx'
import RegLoginButton from "./RegLoginButton.tsx";
import {Link} from "react-router-dom";

export default function Header(): JSX.Element {
    /*
    Страничка своя
    Уведмоления/сообщения
    Войти/регистер
    ЭТО ВСЁ В БОКОВУЮ ШТУКУ
    Сверху какой-нибудь контент?
     */
    
    return <header>
            <h1>Zavodchanins social network kinda</h1>
        <div className={"big_container"}>
        <div className={"button_container"}>
            <Link  to={"/"} className={"header_button"}>Main page</Link>
            <Link to={"/messages"} className={"header_button"}>Messages</Link>
            <Link to={"/search"} className={"header_button"}>Search engine</Link>
        </div>
            <RegLoginButton></RegLoginButton>
        </div>
        
        </header>
}


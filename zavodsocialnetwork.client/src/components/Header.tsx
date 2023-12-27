//import { useEffect, useState } from 'react';
import '../scss/Header.scss';
import './RegLoginButton.tsx'
import RegLoginButton from "./RegLoginButton.tsx";

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
        <div className={"button_container"}>
            <a className={"header_button"}>Your profile</a>
            <a className={"header_button"}>Messages</a>
            <a className={"header_button"}>Search engine</a>
        </div>
            <RegLoginButton></RegLoginButton>
        
        </header>
}


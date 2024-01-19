//import { useEffect, useState } from 'react';
import '../scss/Header.scss';
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
        <div className={"sub_div"}>
            <div className={"logo"}><h1>Zavodchanins social network kinda</h1></div>
        <div className={"big_container"}>
        <div className={"button_container"} id={"common_buttons"}>
            <Link  to={"/"} className={"header_button"}>Main page</Link>
            <Link to={"/messages"} className={"header_button"}>Messages</Link>
            <Link to={"/search"} className={"header_button"}>Search engine</Link>
        </div>
            <div className={"button_container"} id={"reg_log"}>
                <Link to={"/register"} className={"header_button"}>Register</Link>
                <Link to={"/login"} className={"header_button"}>Login</Link>
            </div>
        </div>
        </div>
        </header>
}


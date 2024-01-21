//import { useEffect, useState } from 'react';
import '../scss/Header.scss';
import {Link} from "react-router-dom";
import {clearCurrentUser} from "../scripts/reg_log.ts";
import React from "react";


export default function Header(): JSX.Element {
    const [isLogged, setLogged] = React.useState<boolean>();
    
    if(isLogged == false) {
        return <header>
            <div className={"sub_div"}>
                <div className={"logo"}><h1>Zavodchanins social network kinda</h1></div>
                <div className={"big_container"}>
                    <div className={"button_container"} id={"common_buttons"}>
                        <Link to={"/"} className={"header_button"}>Main page</Link>
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
    } else {
        return <header>
            <div className={"sub_div"}>
                <div className={"logo"}><h1>Zavodchanins social network kinda</h1></div>
                <div className={"big_container"}>
                    <div className={"button_container"} id={"common_buttons"}>
                        <Link to={"/"} className={"header_button"}>Main page</Link>
                        <Link to={"/messages"} className={"header_button"}>Messages</Link>
                        <Link to={"/search"} className={"header_button"}>Search engine</Link>
                    </div>
                    <div className={"button_container"} id={"signed_out"}>
                        <Link to={'/'} className={"header_button"} onClick={() => {clearCurrentUser(); setLogged(false);}}>Sign out</Link>
                    </div>
                </div>
            </div>
        </header>
    }
}


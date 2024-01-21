import React from "react";
import "../scss/LoginPage.scss"
import {find_user, user_model} from "../scripts/user.ts";
import {setCurrentUser} from "../scripts/reg_log.ts";

const  LoginForm: React.FC = () => {
    const [password, setPassword] = React.useState('');
    const [phone, setPhone] = React.useState('');
    const [isWrong, setWrong] = React.useState<boolean>(false);

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let user : user_model | undefined = undefined;
        try{
            event.type;
            user = find_user(password, phone);
            if (user != undefined)
                setCurrentUser(user);
            else 
                setWrong(true);
        }
        catch(error){
            console.log(error);
            setWrong(true);
            return;
        }
        setWrong(false);
    };

    if(!isWrong) {
        return (<div className={"std"}>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>
                            Phone:
                            <input type={"text"} value={phone} onChange={(event) => setPhone(event.target.value)}/>
                        </label>
                        <label>
                            Password:
                            <input type="password" value={password}
                                   onChange={(event) => setPassword(event.target.value)}/>
                        </label>
                        <label>
                        </label>
                        <button type="submit">Login</button>
                    </div>
                </form>
            </div>
        );
    }
    else {
    return (<div className={"std"}>
        <form onSubmit={handleSubmit}>
            <div>
                <label>
                    Phone:
                    <input type={"text"} value = {phone} onChange={(event)=> setPhone(event.target.value)}/>
                </label>
                <label>
                    Password:
                    <input type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
                </label>
                <label>
                </label>
                <button type="submit" id={"submit_login"}>Login</button>
                <p>Invalid phone/password</p>
            </div>
        </form>
    </div>)
    }
}
export default function RegisterPage(){
    return <LoginForm />
}
    



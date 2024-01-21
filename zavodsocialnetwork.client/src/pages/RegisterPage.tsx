import React from "react";
import "../scss/LoginPage.scss"
import {check_user, find_user, user_model} from "../scripts/user.ts";
import {setCurrentUser} from "../scripts/reg_log.ts";

const  RegisterForm: React.FC = () => {
    const [organisation, setOrganisation] = React.useState('');
    const [password, setPassword] = React.useState('');
    const [phone, setPhone] = React.useState('');

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        let user : user_model | undefined = undefined;
        try{
            event.type;
            if(check_user(organisation, phone)){
                return;
            }
            user = find_user(organisation, phone, password);
            // @ts-ignore
            setCurrentUser(user);
        }
        catch(error){
            console.log(error);
        }
    };

    return (<div className={"std"}>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>
                        Organisation:
                        <input type="text" value={organisation} onChange={(event) => setOrganisation(event.target.value)} />
                    </label>
                    <label>
                        Password:
                        <input type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
                    </label>
                    <label>
                        Phone:
                        <input type={"text"} value = {phone} onChange={(event)=> setPhone(event.target.value)}/>
                    </label>
                    <button  type="submit" id={"submit_register"}>Register</button>
                </div>
            </form>
        </div>
    );
};
export default function RegisterPage(){
    return <RegisterForm />
}



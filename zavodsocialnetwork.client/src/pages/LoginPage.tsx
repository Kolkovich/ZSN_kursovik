import React from "react";
import "../scss/LoginPage.scss"

const  LoginForm: React.FC = () => {
    const [username, setUsername] = React.useState('');
    const [password, setPassword] = React.useState('');

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        console.log('username:', username);
        console.log('password:', password);
    };

    return (<div className={"std"}>
        <form onSubmit={handleSubmit}>
            <div>
            <label>
                Username:
                <input type="text" value={username} onChange={(event) => setUsername(event.target.value)} />
            </label>
            <label>
                Password:
                <input type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
            </label>
            <button type="submit">Login</button>
            </div>
        </form>
        </div>
    );
};
export default function LoginPage(){
    return <LoginForm />
}



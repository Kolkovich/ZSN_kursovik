import '../scss/RegLoginButton.scss';
import {Link} from "react-router-dom";
export default function RegLoginButton(): JSX.Element {
    let elem : JSX.Element;
    if (true){
        elem = <div className={"reg_log_container"}>
        <Link to={"/register"} className={"register"}>Register</Link>
        <Link to={"/login"} className={"login"}>Login</Link>
    </div>
    } else {
        elem = <div className={"registered_user"}>
            <p>Hi, </p>
        </div>
    }
    return elem;
}
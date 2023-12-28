import Header from "./components/Header.tsx";
import {Route, Routes} from "react-router-dom";
import MainPage from "./pages/MainPage.tsx"
import LoginPage from "./pages/LoginPage.tsx";
import RegisterPage from "./pages/RegisterPage.tsx";
export default function App() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/" element={<MainPage />} />
                <Route path={"/login"} element={<LoginPage />}></Route>
                <Route path={"/register"} element={<RegisterPage />}></Route>


            </Routes>
        </>
    )
}

    //Example fetching from controller
    /*async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }*/
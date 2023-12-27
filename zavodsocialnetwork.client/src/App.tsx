import Header from "./components/Header.tsx";
import {Route, Routes} from "react-router-dom";
import MainPage from "./pages/MainPage.tsx"
export default function App() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/" element={<MainPage />} />
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
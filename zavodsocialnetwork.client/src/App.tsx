import './Header.tsx'
import './App.css';
import Header from "./Header.tsx";

export default function App() {
    /*useEffect(() => {
        populateWeatherData();
    }, []);*/
    return (<>
        <Header />
        <div>
            <h1 id="tabelLabel">TESTING___TESTING</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
            <h1>Another shit use of react in C#</h1>
        </div>
        </>
    );

    //Example fetching from controller
    /*async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }*/
}
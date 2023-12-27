import Header from "./components/Header.tsx";
let rows : Array<string> = [];
for(let i : number = 0; i < 50; i++){
    rows.push("<h1>Another shit use of react in C#</h1>");
}
export default function App() {
    /*useEffect(() => {
        populateWeatherData();
    }, []);*/
    return (<>
        <Header />
        <div>
            <h1 id="tabelLabel">TESTING___TESTING</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <h1>{rows}</h1>
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
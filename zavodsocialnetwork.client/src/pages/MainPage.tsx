import '../scss/MainPage.scss'

export default function mainPage(){
    
    return <div className={"mainPage"}>
        <div className={"leftSided"} id={"Top"}> <h2 id={"big_h2"}>Добро пожаловать на сайт!</h2> </div>
        <div className={"rightSided"}><p>Данный сайт представляет проект по реализации сайта c функционалом сбыта и контрактов</p>
        <p>Не смотря на большую задержку, для себя мы почерпнули ненасытно много</p>
            <p>Например, что такое React, frontent впринципе и его инструменты</p>
            <p>Как может соединяться бек и фронт и почему это сложно</p>
            <p>50 тысяч видов что-то около бд и для чего они нужны</p>
            <p>Прямо сейчас стек состоит из такого: Vite, React, Typescript, MaterialUI (not implemented yet), ASP.NET CORE, Postgresql (тут ещё должен был быть ElasticSearch, но уже поздновато)</p>
        </div>
    </div>
}


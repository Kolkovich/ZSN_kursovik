export default function Head(title : string): JSX.Element {
   
    return <head>
        <meta charSet="utf-8" />
        <link rel="shortcut icon" href="https://developer.mozilla.org/static/img/favicon32.png" type="image/x-icon" />
        <title>
            {title}
        </title>
    </head>
}
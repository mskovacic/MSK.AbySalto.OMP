import './App.css'
import Items from './Items'
import Basket from './Basket'
import WeatherData from './WeatherData'
import { Routes, Route } from 'react-router'

function App() {

    return (    
        <div className="app-container">
            <header className="app-header">
                <h1 className="app-title">Abysalto webshop</h1>
                <p className="app-subtitle">Modern distributed application development</p>
            </header>

            <main className="main-content">
                <Routes>
                    <Route path="/" element={<Items />} />
                    <Route path="/details" element={<Basket />} />
                    <Route path="/weather" element={<WeatherData />} />
                </Routes>   
            </main>

            <footer className="app-footer">
                <nav aria-label="Footer navigation">
                    <a href="https://aspire.dev" target="_blank" rel="noopener noreferrer">
                        Learn more about Aspire<span className="visually-hidden"> (opens in new tab)</span>
                    </a>
                    <a
                        href="https://github.com/dotnet/aspire"
                        target="_blank"
                        rel="noopener noreferrer"
                        className="github-link"
                        aria-label="View Aspire on GitHub (opens in new tab)"
                    >
                        <img src="/github.svg" alt="" width="24" height="24" aria-hidden="true" />
                        <span className="visually-hidden">GitHub</span>
                    </a>
                </nav>
            </footer>
        </div>
    )
}

export default App
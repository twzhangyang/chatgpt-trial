import React from "react"
import logo from "./logo.svg"
import "./App.css"
import { Routes, Route, Outlet, Link } from "react-router-dom"
import Student from "./StudentPage"
import StudentNew from "./StudentNewPage"

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo"/>
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>

        <div>
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/student">Dashboard</Link>
              </li>
              <li>
                <Link to="/student-new">Nothing Here</Link>
              </li>
            </ul>
          </nav>
        </div>
      </header>


      {/*<Routes>*/}
      {/*  <Route path="/" element={<App/>}/>*/}
      {/*  <Route path="student" element={<Student/>}/>*/}
      {/*  <Route path="student-new" element={<StudentNew/>}/>*/}
      {/*</Routes>*/}
    </div>
  )
}

export default App

import "./App.css"
import Login from "./Login"
import { Link, Outlet, Route, Routes } from "react-router-dom"
import NoMatch from "./NoMatch"
import { StudentList } from "./Students"

function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout/>}>
        <Route index element={<Login/>}/>
        <Route path="students" element={<StudentList/>}/>
        <Route path="dashboard" element={<Dashboard/>}/>
        <Route path="*" element={<NoMatch/>}/>
      </Route>
    </Routes>
  )
}

function Layout() {
  return (
      <div className="row">
        <div className="col-md-3">
          <nav>
            <ul>
              <li>
                <Link to="/">Login</Link>
              </li>
              <li>
                <Link to="/students">Students</Link>
              </li>
              <li>
                <Link to="/dashboard">Dashboard</Link>
              </li>
              <li>
                <Link to="/nothing-here">Nothing Here</Link>
              </li>
            </ul>
          </nav>
        </div>
        <div className="col-md-8">
          <Outlet/>
        </div>
        <div className="col-md-1"></div>
      </div>
  )
}

function Home() {
  return (
    <div>
      <h2>Home</h2>
    </div>
  )
}

function Dashboard() {
  return (
    <div>
      <h2>Dashboard</h2>
    </div>
  )
}

export default App

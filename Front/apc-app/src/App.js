import React from 'react'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom"
import TodoList from "./pages/TodoList"
import UserList from "./pages/UserList"
import TodoCreate from "./pages/TodoCreate"
import TodoUpdate from "./pages/TodoUpdate"
import Login from "./pages/Login"
import Registration from "./pages/Registration"

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<Login />} />
        <Route exact path="/signup" element={<Registration />} />
        <Route exact path="/dashboard" element={<TodoList />} />
        <Route path="/create" element={<TodoCreate />} />
        <Route path="/users" element={<UserList />} />
        <Route path="/update/:id" element={<TodoUpdate />} />
      </Routes>
    </Router>
  );
}

export default App;
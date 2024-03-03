import React, { useState, useEffect } from 'react'
import { Link,useNavigate } from "react-router-dom"
import Swal from 'sweetalert2'
import axios from 'axios'
import Layout from "../components/Layout"


function Registration() {
    const navigate = useNavigate();
    const [userName, setName] = useState('');
    const [password, setPassword] = useState('')
    const [isSaving, setIsSaving] = useState(false)
    const instance = axios.create({
        baseURL: 'https://localhost:7014/',
    });
    const handleSave = () => {
        setIsSaving(true);
        instance.post('/api/auth/register', {
            userName: userName,
            password: password
          })
          .then(function (response) {
            Swal.fire({
                icon: 'success',
                title: 'user registered',
                showConfirmButton: false,
                timer: 2500
            })
            setIsSaving(false);
            setName('')
            setPassword('')
            navigate('/')
          })
          .catch(function (error) {
            console.log(error);
            Swal.fire({
                icon: 'error',
                title: 'An Error Occured!',
                showConfirmButton: false,
                timer: 1500
            })
            setIsSaving(false)
          });
    }
    return (
        <Layout>
            <div className="container">
                <div className="row">
                    <div className="col-sm-9 col-md-7 col-lg-5 mx-auto">
                        <div className="card border-0 shadow rounded-3 my-5">
                            <div className="card-body p-4 p-sm-5">
                                <h5 className="card-title text-center mb-5 fw-light fs-5">Create new account</h5>
                                <form>
                                    <div className="form-floating mb-3">
                                        <input 
                                            value={userName}
                                            onChange={(event)=>{setName(event.target.value)}}
                                            type="text" 
                                            className="form-control"
                                            id="floatingInput"
                                        />
                                        <label htmlFor="floatingInput">UserName</label>
                                       </div>
                                    <div className="form-floating mb-3">
                                        <input 
                                        value={password}
                                        onChange={(event)=>{setPassword(event.target.value)}}
                                        type="password" 
                                        className="form-control" 
                                        id="floatingPassword" 
                                        placeholder="Password" />
                                        <label htmlFor="floatingPassword">Password</label>
                                    </div>
                                    <div className="d-grid">
                                        <button 
                                        disabled={isSaving}
                                        onClick={handleSave} 
                                        className="btn btn-primary btn-login text-uppercase fw-bold" 
                                        type="button">
                                            Sign Up
                                        </button>
                                    </div>
                                    <hr className="my-4"></hr>

                                    <div className="d-grid">
                                        <Link className="btn btn-outline-primary btn-login text-uppercase fw-bold" to="/">Log in</Link>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Layout>
    );
}

export default Registration;
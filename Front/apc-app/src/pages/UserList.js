import React, { useState, useEffect } from 'react'
import { Link, useNavigate } from "react-router-dom"
import Swal from 'sweetalert2'
import axios from 'axios'
import Layout from "../components/Layout"

function UserList() {
    const navigate = useNavigate();
    const [UserList, setUserList] = useState([])

    useEffect(() => {
        if (localStorage.getItem('token') == null) {
            navigate("/");
        }
        fetchUserList()
    }, [])

    const axiosInstance = axios.create({
        baseURL: 'https://localhost:7014/',
        headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
    });


    const fetchUserList = () => {
        axiosInstance.get('/api/users')
            .then(function (response) {
                console.log(response.status)
                setUserList(response.data);
            })
            .catch(function (error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Forbidden',
                    showConfirmButton: false,
                    timer: 5500
                })
            })
    }

    const handleDelete = (id) => {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                axiosInstance.delete(`/api/user/${id}`)
                    .then(function (response) {
                        Swal.fire({
                            icon: 'success',
                            title: 'User deleted successfully!',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        fetchUserList()
                    })
                    .catch(function (error) {
                        console.log(error)
                        Swal.fire({
                            icon: 'error',
                            title: 'An Error Occured!',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    });
            }
        })
    }

    const Logout = () => {
        localStorage.removeItem("token");
        navigate("/");
    }

    return (
        <Layout>
            <div className="container">
                <h2 className="text-center mt-5 mb-3">User list</h2>
                <div className="card">
                    <div className="card-header">
                        <Link className="btn btn-outline-primary" to="/dashboard">View Tasks </Link>
                        <button onClick={() => Logout()} className="btn btn-outline-danger float-end"> Logout </button>
                    </div>
                    <div className="card-body">

                        <table className="table table-bordered">
                            <thead>
                                <tr>
                                    <th>UserName</th>
                                    <th width="240px">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                {UserList.map((user, key) => {
                                    return (
                                        <tr key={key}>
                                            <td>{user.userName}</td>
                                            <td>
                                                <button
                                                    onClick={() => handleDelete(user.id)}
                                                    className="btn btn-outline-danger mx-1">
                                                    Delete
                                                </button>
                                            </td>
                                        </tr>
                                    )
                                })}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </Layout>
    );
}

export default UserList;
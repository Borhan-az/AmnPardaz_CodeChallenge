import React, { useState, useEffect } from 'react'
import { Link, useNavigate } from "react-router-dom"
import Swal from 'sweetalert2'
import axios from 'axios'
import Layout from "../components/Layout"


function ProjecCreate() {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('')
    const [isSaving, setIsSaving] = useState(false)
    const navigate = useNavigate();

    useEffect(() => {
        if (localStorage.getItem('token') == null) {
            navigate("/");
        }
    }, [])

    const axiosInstance = axios.create({
        baseURL: 'https://localhost:7014/',
        headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
          },
    });

    const handleSave = () => {
        setIsSaving(true);
        axiosInstance.post('api/tasks', {
            title: title,
            description: description
        })
            .then(function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Task saved successfully!',
                    showConfirmButton: false,
                    timer: 1500
                })
                setIsSaving(false);
                setTitle('')
                setDescription('')
            })
            .catch(function (error) {
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
                <h2 className="text-center mt-5 mb-3">Create New Task</h2>
                <div className="card">
                    <div className="card-header">
                        <Link
                            className="btn btn-outline-info float-right"
                            to="/dashboard">View All Tasks
                        </Link>
                    </div>
                    <div className="card-body">
                        <form>
                            <div className="form-group">
                                <label htmlFor="name">Title</label>
                                <input
                                    onChange={(event) => { setTitle(event.target.value) }}
                                    value={title}
                                    type="text"
                                    className="form-control"
                                    id="title"
                                    name="title" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="description">Description</label>
                                <textarea
                                    value={description}
                                    onChange={(event) => { setDescription(event.target.value) }}
                                    className="form-control"
                                    id="description"
                                    rows="3"
                                    name="description"></textarea>
                            </div>
                            <button
                                disabled={isSaving}
                                onClick={handleSave}
                                type="button"
                                className="btn btn-outline-primary mt-3">
                                Save Task
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </Layout>
    );
}

export default ProjecCreate;
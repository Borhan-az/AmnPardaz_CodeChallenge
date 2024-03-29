import React, { useState, useEffect } from 'react'
import { Link, useParams, useNavigate } from "react-router-dom"
import Swal from 'sweetalert2'
import axios from 'axios'
import Layout from "../components/Layout"

function TaskUpdate() {
    const [id, setId] = useState(useParams().id)
    const [name, setName] = useState('');
    const [description, setDescription] = useState('')
    const [isSaving, setIsSaving] = useState(false)
    const navigate = useNavigate();

    const axiosInstance = axios.create({
        baseURL: 'https://localhost:7014/',
        headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
    });
    useEffect(() => {
        if (localStorage.getItem('token') == null) {
            navigate("/");
        }

        axiosInstance.get(`/api/Tasks/${id}`)
            .then(function (response) {
                let task = response.data
                setId(task.id);
                setName(task.title);
                setDescription(task.description);
            })
            .catch(function (error) {
                Swal.fire({
                    icon: 'error',
                    title: 'An Error Occured!',
                    showConfirmButton: false,
                    timer: 1500
                })
            })

    }, [])


    const handleSave = () => {
        setIsSaving(true);
        axiosInstance.put(`/api/tasks`, {
            id:id,
            title: name,
            description: description
        })
            .then(function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'task updated successfully!',
                    showConfirmButton: false,
                    timer: 1500
                })
                setIsSaving(false);
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
                <h2 className="text-center mt-5 mb-3">Update task</h2>
                <div className="card">
                    <div className="card-header">
                        <Link
                            className="btn btn-outline-info float-right"
                            to="/dashboard">View All tasks
                        </Link>
                    </div>
                    <div className="card-body">
                        <form>
                            <div className="form-group">
                                <label htmlFor="name">Title</label>
                                <input
                                    onChange={(event) => { setName(event.target.value) }}
                                    value={name}
                                    type="text"
                                    className="form-control"
                                    id="name"
                                    name="name" />
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
                                className="btn btn-outline-success mt-3">
                                Update task
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </Layout>
    );
}

export default TaskUpdate;
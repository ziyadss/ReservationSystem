<script lang="ts">
    import '../../styles.css';
    import { browser } from "$app/environment"
    import { onMount } from "svelte";
    import Swal from 'sweetalert2';
    import 'sweetalert2/src/sweetalert2.scss'

    let token = '';
    onMount(async () => {
        let _token;
        let _role;
        if (browser) {
            _token = window.localStorage.getItem('token');
            _role = window.localStorage.getItem('role');
        }

        if (_token) {
            if (_role == 'User') {
                alert("You are not authorized to access this page. Redirecting to main page")
                window.location.replace('/');
            }
            else if (_role == 'Manager') {
                alert("You are not authorized to access this page. Redirecting to main page")
                window.location.replace('/manager/match/list');
            }
            token = _token;
        }

        getUsers();
    });

    let take = 50;
    let skip = 0;

    let geturl = 'https://localhost:7123/api/users?skip=' + skip + '&take=' + take;

    let previous = Array<string>();
    let next = '';

    let users = [{
        userName: '',
        firstName: '',
        lastName: '',
        email: '',
        birthdate: '',
        gender: '',
        nationality: '',
        role: ''
    }];
    users.pop();

    async function getUsers() {
        const response = await fetch(geturl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + token
            }
        });

        if (response.ok) {
            const json = await response.json();
            users = json.items;
            skip = json.skip;
            take = json.take;
            next = json.next as string;
        } else {
            alert("HTTP-Error: " + response.status);
        }
    }

    async function nextPage() {
        if (next != '') {
            previous.push(geturl);
            geturl = next;
            await getUsers();
        }
    }

    async function previousPage() {
        if (previous.length > 0) {
            geturl = previous.pop() as string;
            await getUsers();
        }
    }

    async function deleteUser(username: string) {
        Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
        }).then(async (result: Swal.SweetAlertResult) => {
            if (result.value) {
                const response = await fetch('https://localhost:7123/api/users/' + username, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        Authorization: 'Bearer ' + token
                    }
                });

                if (response.ok) {
                    Swal.fire(
                    'Deleted!',
                    'The user has been deleted.',
                    'success'
                    );
                    await getUsers();
                } else {
                    Swal.fire(
                    'Failed!',
                    'HTTP-Error: ' + response.status,
                    'error'
                    );
                }
            }
        });
    }

    async function authorizeUser(username: string) {
        Swal.fire({
        title: 'Are you sure?',
        text: "You want to authorize this user?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, authorize it!'
        }).then(async (result: Swal.SweetAlertResult) => {
            if (result.value) {
                const response = await fetch('https://localhost:7123/api/users/' + username, {
                    method: 'PATCH',
                    headers: {
                        'Content-Type': 'application/json',
                        Authorization: 'Bearer ' + token
                    },
                    body: JSON.stringify({
                        role: 'Manager'
                    })
                });

                if (response.ok) {
                    Swal.fire(
                    'Authorized!',
                    'The user has been authorized.',
                    'success'
                    );
                    await getUsers();
                } else {
                    Swal.fire(
                    'Failed!',
                    'HTTP-Error: ' + response.status,
                    'error'
                    );
                }
            }
        });
    }

</script>

<svelte:head>
        <title>Manage Users</title>
        <meta name="description" content="Qatar 2022&trade;" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
</svelte:head>

<div class="container mt-5">
    <h1>Manage Users</h1>
    <table class="table table-striped mt-3">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Username</th>
                <th scope="col">First Name</th>
                <th scope="col">Last Name</th>
                <th scope="col">Email</th>
                <th scope="col">Birthdate</th>
                <th scope="col">Gender</th>
                <th scope="col">Nationality</th>
                <th scope="col">Role</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            {#each users as user, i}
            <tr>
                <th scope="row">{skip + i + 1}</th>
                <td>{user.userName}</td>
                <td>{user.firstName}</td>
                <td>{user.lastName}</td>
                <td>{user.email}</td>
                <td>{user.birthdate}</td>
                <td>{user.gender}</td>
                <td>{user.nationality}</td>
                <td>{user.role}</td>
                <td>
                    <button class="btn btn-danger" on:click={() => deleteUser(user.userName)}>Delete</button>
                </td>
                <td>
                    <button class="btn btn-primary" on:click={() => authorizeUser(user.userName)} disabled={user.role.toLowerCase() == "manager" || user.role.toLowerCase() == "admin"}>Authorize</button>
                </td>
            </tr>
            {/each}
        </tbody>
    </table>
    <div class="d-flex justify-content-between mt-3">
        <button class="btn btn-primary" on:click={previousPage} disabled={previous.length === 0}>Previous</button>
        <button class="btn btn-primary" on:click={nextPage} disabled={!next}>Next</button>
    </div>
</div>

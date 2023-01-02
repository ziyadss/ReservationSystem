<script lang="ts">
    import '../../styles.css';
    import { browser } from "$app/environment"
    import { onMount } from "svelte";

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
        const response = await fetch('https://localhost:7123/api/users/' + username, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + token
            }
        });

        if (response.ok) {
            alert("User deleted successfully");
            await getUsers();
        } else {
            alert("HTTP-Error: " + response.status);
        }
    }

    async function authorizeUser(username: string) {
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
            alert("User authorized successfully");
            await getUsers();
        } else {
            alert("HTTP-Error: " + response.status);
        }
    }

    getUsers();

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
                    <button class="btn btn-danger" data-toggle="modal" data-target="#deleteModal_{user.userName}">Delete</button>
                    <!-- Delete Modal -->
                    <div class="modal fade" id="deleteModal_{user.userName}" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="deleteModalLabel">Confirm Delete</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    Are you sure you want to delete user {user.userName}?
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <button type="button" class="btn btn-danger" on:click={() => deleteUser(user.userName)} data-dismiss="modal">Delete</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <button class="btn btn-primary" data-toggle="modal" data-target="#authorizeModal_{user.userName}">Authorize</button>
                    <!-- Authorize Modal -->
                    <div class="modal fade" id="authorizeModal_{user.userName}" tabindex="-1" role="dialog" aria-labelledby="authorizeModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="authorizeModalLabel">Confirm Authorize</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    Are you sure you want to authorize user {user.userName}?
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <button type="button" class="btn btn-primary" on:click={() => authorizeUser(user.userName)} data-dismiss="modal">Authorize</button>
                                </div>
                            </div>
                        </div>
                    </div>
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

<script lang='ts'>
    import { browser } from "$app/environment"
    import { onMount } from "svelte";
	import { enhance } from "$app/forms";
    import participants from '$lib/mock/participating-countries.json';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';

	let token = '';
    // list of objects with name and id
    let stadiums: { name: string, capacity: number }[] = [];

	onMount(async () => {
		let _token;
		let _role;
		if (browser) {
			_token = window.localStorage.getItem('token');
			_role = window.localStorage.getItem('role');
		}

		if (_token) {
			if (_role == 'User') {
				window.location.replace('/');
			}
			else if (_role == 'Admin') {
				window.location.replace('/admin/list');
			}
			token = _token;

		}
	});

    let stadium = {
        name: '',
        rows: 0,
        columns: 0,
    }

    async function createStadium() {
        if (stadium.rows <= 0) {
            Swal.fire(
            'Invalid!',
            'Rows cannot be zero.',
            'error'
            );
            return;
        }
        if (stadium.columns <= 0) {
            Swal.fire(
            'Invalid!',
            'Columns cannot be zero.',
            'error'
            );
            return;
        }

        const response = await fetch('https://localhost:7123/api/stadiums', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + token
            },
            body: JSON.stringify(
                stadium
            )
        });
        if (response.ok) {
            const data = await response.json();
            Swal.fire(
            'Stadium Added!',
            'Stadium has been added.',
            'success'
            );
            window.location.replace('/manager/stadium/create');
        }
        else {
            const error = await response.json();
            Swal.fire(
            'Failed!',
            'Error adding stadium: ' + error.InvalidMessage,
            'success'
            );
            return;
        }
    }   
</script>

<svelte:head>
    <title>Add Stadium</title>
</svelte:head>

<div class="container justify-content-center p-3">
    <div class="card" style="width=18rem">
        <div class="card-header bg-dark text-white">
            <h4>Add New Stadium</h4>
        </div>
        <div class="text-danger"></div>
        <form on:submit|preventDefault={createStadium} id="add-match-form">
            <div class="card-body">
                <div class="form-row row">
                    <div class="form-group col-6">
                        <label for="referee" class="col-form-label">Stadium Name</label>
                        <input type="text" class="form-control" bind:value={stadium.name} required/>
                    </div>
                </div>
                <div class="form-row row">
                    <div class="form-group col-6">
                        <label for="time" class="col-form-label">Rows</label>
                        <input type="number" class="form-control" bind:value={stadium.rows} required/>
                    </div>
                    <div class="form-group col-6">
                        <label for="time" class="col-form-label">Columns</label>
                        <input type="number" class="form-control" bind:value={stadium.columns} required/>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <div class="form-row">
                    <button class="btn btn-primary" type="submit">Add Stadium</button>
                </div>
            </div>
        </form>
    </div>
</div>
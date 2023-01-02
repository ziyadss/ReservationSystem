<script>
    import { browser } from "$app/environment"
    import { onMount } from "svelte";
	import { redirect } from "@sveltejs/kit";
    import Swal from 'sweetalert2';
    import 'sweetalert2/src/sweetalert2.scss'

	let token = '';
    let matches = [];
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
            await getMatches();
		}
	});

    async function getMatches() {
        const response = await fetch('https://localhost:7123/api/matches', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });
        if (response.ok) {
            const data = await response.json();
            matches = data.items;
        }
    }
</script>

<svelte:head>
    <title>Match List</title>
</svelte:head>


<div class="container mt-5">
    <div class="row">
        <div class="col-3">
            <h1>Match List</h1>
        </div>
        <div class="col-1" style="margin: auto auto auto 0;">
            <button type="button" class="btn btn-link btn-sm" data-ripple-color="dark">
                <a href='/manager/match/create'><i class="fas fa-plus"></i></a>
            </button>
        </div>
    </div>
    <table class="table table-striped mt-3">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Home Team</th>
                <th scope="col">Away Team</th>
                <th scope="col">Stadium</th>
                <th scope="col">Date</th>
                <th scope="col">Referee</th>
                <th scope="col">First Linesman</th>
                <th scope="col">Second Linesman</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            {#each matches as match, i}
                <tr>
                    <th scope="row">{i + 1}</th>
                    <td>{match.homeTeam}</td>
                    <td>{match.awayTeam}</td>
                    <td>{match.stadium}</td>
                    <td>{new Date(match.time).toLocaleTimeString([], {
                        year: 'numeric',
                        month: '2-digit',
                        day: '2-digit',
                        hour: '2-digit',
                        minute: '2-digit',
                    })}</td>
                    <td>{match.referee}</td>
                    <td>{match.firstLinesman}</td>
                    <td>{match.secondLinesman}</td>
                    <td>
                        <a class="btn btn-danger" href="/manager/match/update/{match.id}">Edit</a>
                    </td>
                </tr>
            {/each}
        </tbody>
    </table>
</div>
<script>
    import { browser } from "$app/environment"
    import { onMount } from "svelte";
	import { redirect } from "@sveltejs/kit";

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
	});
    const tempMatches = [
        {
            homeTeam: "Argentine",
            awayTeam: "Brazil",
            stadiumName: "Al Bayt Stadium",
            time: "2021-06-12T00:00:00",
            referee: "Saeed Al Muhairi",
            firstLinesMan: "Mohammed Al Shamsi",
            secondLinesMan: "Khaled Al Mousa",
        }
    ]
</script>

<svelte:head>
    <title>WC22 Match List</title>
</svelte:head>

<div class="d-flex flex-row row container mx-2 my-2">
    <div class="col-6 px-5">
        <h2>Match List</h2>
    </div>
    <div class="col-1">
    </div>
    <div class="col-1">
    </div>
    <div class="col-1">
    </div>
    <div class="col-1">
    </div>
    <div class="col-1">
    </div>
    <div class="col-1 my-2">
        <button type="button" class="align-items-center btn btn-primary btn-sm" data-ripple-color="dark">
            <i class="fas fa-plus"></i>
        </button>
    </div>
</div>

<div class="d-flex my-4 flex-row container">

    <table class="table table-bordered align-middle">
        <thead>
            <tr class="table-dark">
                <th scope="col">#</th>
                <th scope="col">Home Team</th>
                <th scope="col">Away Team</th>
                <th scope="col">Stadium</th>
                <th scope="col">Date</th>
                <th scope="col">Referee</th>
                <th scope="col" colspan="2">Linesmen</th>
                <th scope="col" colspan="2">Actions</th>
            </tr>
        </thead>
        <tbody>
            {#each tempMatches as match}
                <tr>
                    <th scope="row">1</th>
                    <td>{match.homeTeam}</td>
                    <td>{match.awayTeam}</td>
                    <td>{match.stadiumName}</td>
                    <td>{new Date(match.time).toLocaleTimeString([], {
                        year: 'numeric',
                        month: '2-digit',
                        day: '2-digit',
                        hour: '2-digit',
                        minute: '2-digit',
                    })}</td>
                    <td>{match.referee}</td>
                    <td>{match.firstLinesMan}</td>
                    <td>{match.secondLinesMan}</td>
                    <td>
                        <button type="button" class="btn btn-primary btn-sm px-3" data-ripple-color="dark">
                        <i class="fas fa-pen"></i>
                        </button>
                    </td>
                    <td>
                        <button type="button" class="btn btn-danger btn-sm px-3" data-ripple-color="dark">
                        <i class="fas fa-times"></i>
                        </button>
                    </td>
                </tr>
            {/each}
        </tbody>
    </table>
</div>
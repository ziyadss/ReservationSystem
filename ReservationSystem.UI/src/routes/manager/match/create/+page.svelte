<script lang='ts'>
    import { browser } from "$app/environment"
    import { onMount } from "svelte";
	import { enhance } from "$app/forms";
    import participants from '$lib/mock/participating-countries.json';

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
        await getStadiums();
	});


    const date = new Date();
    let match = {
        homeTeam: '',
        awayTeam: '',
        stadium: '',
        time: date,
        referee: '',
        firstLinesman: '',
        secondLinesman: ''
    }

    async function getStadiums() {
        const response = await fetch('https://localhost:7123/api/stadiums', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });
        if (response.ok) {
            const data = await response.json();
            stadiums = data;
        }
    };

    async function createMatch() {
        if (match.time < new Date()) {
            alert('Match time cannot be in the past');
            return;
        }
        if (match.homeTeam == match.awayTeam) {
            alert('Home team and away team cannot be the same');
            return;
        }

        const response = await fetch('https://localhost:7123/api/matches', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'Bearer ' + token
            },
            body: JSON.stringify(
                match
            )
        });
        if (response.ok) {
            const data = await response.json();
			alert('Success editing match');
            window.location.replace('/manager/match/list');
        }
        else {
            console.log(response.json());
            alert('Error creating match:');
            return;
        }
    }   
</script>

<svelte:head>
    <title>Create Match</title>
</svelte:head>

<div class="container justify-content-center p-3">
    <div class="card" style="width=18rem">
        <div class="card-header bg-dark text-white">
            <h4>Add New Match</h4>
        </div>
        <div class="text-danger"></div>
        <form on:submit|preventDefault={createMatch} id="add-match-form">
            <div class="card-body">
                <div class="form-row row">
                    <div class="form-group col-6">
                        <label for="homeTeam" class="col-form-label">Home Team</label>
                        <select class="form-control" name="homeTeam" bind:value={match.homeTeam} required>
                            {#each participants as participant}
                                <option value={participant.name}>{participant.name}</option>
                            {/each}
                        </select>
                    </div>
                    <div class="form-group col-6">
                        <label for="awayTeam" class="col-form-label">Away Team</label>
                        <select class="form-control" name="awayTeam" bind:value={match.awayTeam} required>
                            {#each participants as participant}
                                <option value={participant.name}>{participant.name}</option>
                            {/each}
                        </select>
                    </div>
                </div>
                <div class="form-row row">
                    <div class="form-group col">
                        <label for="time" class="col-form-label">Time</label>
                        <input type="datetime-local" class="form-control" bind:value={match.time} required/>
                    </div>
                </div>
                <div class="form-row row">
                    <div class="form-group col">
                        <label for="stadium" class="col-form-label">Stadium</label>
                        <select class="form-control" bind:value={match.stadium} required>
                            {#each stadiums as stadium}
                                <option value={stadium.name}>{stadium.name}</option>
                            {/each}
                        </select>
                    </div>
                    <div class="form-group col">
                        <label for="referee" class="col-form-label">Referee</label>
                        <input type="text" class="form-control" bind:value={match.referee} required/>
                    </div>
                </div>
                <div class="form-row row">
                    <div class="form-group col">
                        <label for="firstLinesman" class="col-form-label">First Linesman</label>
                        <input type="text" class="form-control" bind:value={match.firstLinesman} required/>
                    </div>
                    <div class="form-group col">
                        <label for="secondLinesman" class="col-form-label">Second Linesman</label>
                        <input type="text" class="form-control" bind:value={match.secondLinesman} required/>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <div class="form-row">
                    <button class="btn btn-primary" type="submit">Add Match</button>
                </div>
            </div>
        </form>
    </div>
</div>
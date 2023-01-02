<script lang="ts">
	import { page } from '$app/stores';
	import { onMount } from 'svelte';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';

	const id = $page.params.id;
	let match = {
		id: 0,
		homeTeam: 'string',
		awayTeam: 'string',
		stadiumName: 'string',
		time: '2023-01-02T01:36:38.458Z',
		stadiumCapacity: 0,
		emptySeats: 0,
		referee: 'string',
		firstLinesman: 'string',
		secondLinesman: 'string',
		availableSeats: [
			{
				ticketNumber: 'string',
				row: 0,
				column: 0
			}
		]
	};
	let stadium = {
		name: 'string',
		capacity: 0,
		rows: 0,
		columns: 0,
		matches: [
			{
				id: 0,
				homeTeam: 'string',
				awayTeam: 'string',
				stadiumName: 'string',
				time: '2023-01-02T01:42:28.305Z'
			}
		]
	};
	// console.log(params.id);
	onMount(async () => {
		const response = await fetch('https://localhost:7123/api/matches/' + id);
		if (response.ok) {
			match = await response.json();
			console.log(match);
			const response2 = await fetch('https://localhost:7123/api/stadiums/' + match.stadiumName);
			if (response2.ok) {
				stadium = await response2.json();
				console.log(stadium);
			} else {
				await Swal.fire({
					title: 'Error!',
					text: 'Error in loading stadium, please try again',
					icon: 'error',
					confirmButtonText: 'OK'
				});
				window.location.replace('/schedule');
			}
		} else {
			await Swal.fire({
				title: 'Error!',
				text: 'Error in loading matches, please try again',
				icon: 'error',
				confirmButtonText: 'OK'
			});
			window.location.replace('/schedule');
		}
	});
</script>

<div class="container" id="reservationPage">
	<div class="row p-5">
		<h1 class="pb-2 border-bottom">Reservation</h1>
		<div class="row p-5 justify-content-center">
			<div class="col p-3 shadow-sm rounded-5" style="background-color: #f7f7f7;">
				<form>
					<h1 class="title">Step 1</h1>
					<div class="form-outline py-2">
						<label for="match">Pick your match</label>
						<select
							class="form-control form-control-lg"
							id="name"
							style="border-radius: 1rem;font-size: 16px;padding: .32rem .75rem;border: none; background-color:white;"
							placeholder="Match"
						/>
					</div>
				</form>
			</div>
		</div>
	</div>
</div>

<script lang="ts">
	import { onMount } from 'svelte';
	import { browser } from '$app/environment';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';
	import { identity } from 'svelte/internal';

	//check if logged in before loading page and get user data
	let token = '';
	let user = {
		userName: '',
		firstName: '',
		lastName: '',
		email: '',
		birthdate: '',
		gender: '',
		nationality: '',
		role: ''
	};
	var password = '';
	var confirmpassword = '';
	let passwordPayload = {
		oldpassword: '',
		newpassword: ''
	};
	let profilePayload = {
		firstName: '',
		lastName: '',
		birthdate: '',
		gender: '',
		nationality: ''
	};
	let reservationsList = [
		{
			id: 1,
			match: {
				id: 2,
				homeTeam: 'Spain',
				awayTeam: 'Germany',
				stadium: 'Ahmad bin Ali Stadium',
				time: '2023-02-02T09:00:00'
			},
			tickets: [
				{
					ticketNumber: '2-5-5',
					row: 5,
					column: 5
				}
			]
		}
	];

	onMount(async () => {
		let _token;
		if (browser) {
			_token = window.localStorage.getItem('token');
		}

		if (_token) {
			token = _token;
			const response = await fetch('https://localhost:7123/api/users/me', {
				method: 'GET',
				headers: {
					'Content-Type': 'application/json',
					Authorization: 'Bearer ' + token
				}
			});
			if (response.ok) {
				user = await response.json();
				console.log(JSON.stringify(user));
				user.birthdate = user.birthdate.split('T')[0].toString();
				profilePayload.firstName = user.firstName;
				profilePayload.lastName = user.lastName;
				profilePayload.birthdate = user.birthdate;
				profilePayload.gender = user.gender;
				profilePayload.nationality = user.nationality;
			}
			const response2 = await fetch('https://localhost:7123/api/reservations', {
				method: 'GET',
				headers: {
					'Content-Type': 'application/json',
					Authorization: 'Bearer ' + token
				}
			});
			if (response2.ok) {
				reservationsList = await response2.json();
				console.log(JSON.stringify(reservationsList));
			}
		} else {
			window.location.replace('/login');
		}
	});

	async function changePasswordRequest() {
		if (password != confirmpassword) {
			await Swal.fire('Invalid!', 'Passwords do not match.', 'error');
			return;
		} else {
			passwordPayload.newpassword = confirmpassword;
		}
		const respone = await fetch('https://localhost:7123/api/auth/password', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
				Authorization: 'Bearer ' + token
			},
			body: JSON.stringify(passwordPayload)
		});
		if (respone.ok) {
			await Swal.fire('Password Changed!', 'Password changed successfully.', 'success');
			window.location.replace('/profile');
		} else {
			await Swal.fire('Failed!', 'Error changing passwords.', 'error');
		}
	}

	async function editProfileRequest() {
		const response = await fetch('https://localhost:7123/api/users/me', {
			method: 'PATCH',
			headers: {
				'Content-Type': 'application/json',
				Authorization: 'Bearer ' + token
			},
			body: JSON.stringify(profilePayload)
		});
		if (response.ok) {
			await Swal.fire('Profile Updated!', 'Profile updated successfully.', 'success');
			window.location.replace('/profile');
		} else {
			await Swal.fire('Failed!', 'Error updating profile.', 'error');
		}
	}

	async function changeDate() {
		// @ts-ignore
		profilePayload.birthdate = document.getElementById('dateEditInput')?.value;
		console.log(profilePayload.birthdate);
	}
	let profileDetails = true;
	let editProfile = false;
	let changePassword = false;

	async function cancelRequest(id: number) {
		const response = await fetch('https://localhost:7123/api/reservations/' + id + '/cancel', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
				Authorization: 'Bearer ' + token
			}
		});
		if (response.ok) {
			await Swal.fire('Reservation Cancelled!', 'Reservation cancelled successfully.', 'success');
			window.location.reload();
		} else {
			await Swal.fire('Failed!', 'Error cancelling reservation. Try again.', 'error');
		}
	}
</script>

<div class="container" id="profile">
	<div class="row p-5">
		<h1 class="pb-2">@{user.userName}</h1>
		<div class="row">
			<div class="col">
				<ul class="nav nav-tabs border-bottom" id="myTab" role="tablist">
					<li class="nav-item" role="presentation">
						<button
							class="nav-link active"
							id="messages-tab"
							data-bs-toggle="tab"
							data-bs-target="#profileDetails"
							type="button"
							role="tab"
							aria-controls="messages"
							aria-selected="false">Profile details</button
						>
					</li>
					<li class="nav-item" role="presentation">
						<button
							class="nav-link"
							id="settings-tab"
							data-bs-toggle="tab"
							data-bs-target="#reservations"
							type="button"
							role="tab"
							aria-controls="settings"
							aria-selected="false">Reservations</button
						>
					</li>
				</ul>

				<!-- Tab panes -->
				<div class="tab-content">
					<div
						class="tab-pane fade show active"
						id="profileDetails"
						role="tabpanel"
						aria-labelledby="messages-tab"
					>
						{#if profileDetails}
							<div class="row my-5 mx-3">
								<div class="col-md-9  p-4 shadow-sm rounded-5" style="background-color:#f7f7f7;">
									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>Username</h3>
										</div>
										<div class="col">
											<h4>@{user.userName}</h4>
										</div>
									</div>
									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>First Name</h3>
										</div>
										<div class="col">
											<h4>{user.firstName}</h4>
										</div>
									</div>
									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>Last Name</h3>
										</div>
										<div class="col">
											<h4>{user.lastName}</h4>
										</div>
									</div>
									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>Email</h3>
										</div>
										<div class="col">
											<h4>{user.email}</h4>
										</div>
									</div>

									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>BirthDate</h3>
										</div>
										<div class="col">
											<h4>{user.birthdate}</h4>
										</div>
									</div>
									<div class="row p-3 border-bottom">
										<div class="col">
											<h3>Nationality</h3>
										</div>
										<div class="col">
											<h4>{user.nationality}</h4>
										</div>
									</div>
									<div class="row p-3 ">
										<div class="col">
											<h3>Gender</h3>
										</div>
										<div class="col">
											<h4>{user.gender}</h4>
										</div>
									</div>
								</div>
								<div class="col-md-2 mx-3">
									<button
										class="btn w-100"
										style="font-size: 1.2rem;"
										on:click={() => {
											profileDetails = false;
											editProfile = true;
										}}>Edit Profile</button
									>
									<button
										class="btn w-100 my-3"
										style="font-size: 1.2rem;"
										on:click={() => {
											profileDetails = false;
											changePassword = true;
										}}>Change Password</button
									>
								</div>
							</div>
						{:else if changePassword}
							<form on:submit|preventDefault={changePasswordRequest} id="changePasswordForm">
								<div class="row my-5 mx-3">
									<div class="col-md-9  p-4 shadow-sm rounded-5" style="background-color:#f7f7f7;">
										<div class="form-outline">
											<label class="input-title" for="oldp">Old Password</label>
											<input
												type="password"
												class="form-control form-control-lg"
												name="oldp"
												id="oldp"
												bind:value={passwordPayload.oldpassword}
											/>
										</div>
										<div class="form-outline">
											<label class="input-title" for="oldp">New Password</label>
											<input
												type="password"
												class="form-control form-control-lg"
												name="oldp"
												id="oldp"
												bind:value={password}
											/>
										</div>
										<div class="form-outline">
											<label class="input-title" for="oldp">Confirm Password</label>
											<input
												type="password"
												class="form-control form-control-lg"
												name="oldp"
												id="oldp"
												bind:value={confirmpassword}
											/>
										</div>
									</div>
									<div class="col-md-2 mx-3">
										<button class="btn w-100" style="font-size: 1.2rem;" type="submit"
											>Confirm</button
										>
										<button
											class="btn btn-cancel w-100 my-3"
											style="font-size: 1.2rem;"
											on:click={() => {
												profileDetails = true;
												changePassword = false;
												password = '';
												confirmpassword = '';
												passwordPayload.oldpassword = '';
											}}>Cancel</button
										>
									</div>
								</div>
							</form>
						{:else if editProfile}
							<form on:submit|preventDefault={editProfileRequest} id="editProfileForm">
								<div class="row my-5 mx-3">
									<div class="col-md-9  p-4 shadow-sm rounded-5" style="background-color:#f7f7f7;">
										<div class="form-outline">
											<label class="input-title" for="oldp">First Name</label>
											<input
												type="text"
												class="form-control form-control-lg"
												name="oldp"
												id="oldp"
												bind:value={profilePayload.firstName}
											/>
										</div>
										<div class="form-outline">
											<label class="input-title" for="oldp">Last Name</label>
											<input
												type="text"
												class="form-control form-control-lg"
												name="oldp"
												id="oldp"
												bind:value={profilePayload.lastName}
											/>
										</div>
										<div class="form-outline">
											<label class="input-title" for="oldp">BirthDate</label>
											<input
												id="dateEditInput"
												value={user.birthdate.slice(0, 10)}
												on:change={changeDate}
												class="form-control form-control-lg"
												type="date"
												name="birthDate"
											/>
										</div>
										<div class="form-outline">
											<label class="input-title" for="oldp">Gender</label>
											<select
												class="form-control form-control-lg"
												bind:value={profilePayload.gender}
												required
												name="gender"
												style="border-radius: 1rem;font-size: 16px;padding: .32rem .75rem;border: none; background-color:white;"
											>
												<option value="3">Female</option>
												<option value="2">Male</option>
												<option value="1">Unspecified</option>
												<option value="0">Unknown</option>
											</select>
										</div>
									</div>
									<div class="col-md-2 mx-3">
										<button class="btn w-100" style="font-size: 1.2rem;" type="submit"
											>Confirm</button
										>
										<button
											class="btn btn-cancel w-100 my-3"
											style="font-size: 1.2rem;"
											on:click={() => {
												profileDetails = true;
												editProfile = false;
												profilePayload.firstName = user.firstName;
												profilePayload.lastName = user.lastName;
												profilePayload.birthdate = user.birthdate;
												profilePayload.gender = user.gender;
											}}>Cancel</button
										>
									</div>
								</div>
							</form>
						{/if}
					</div>
					<div
						class="tab-pane fade "
						id="reservations"
						role="tabpanel"
						aria-labelledby="settings-tab"
					>
						{#each reservationsList as res, i}
							<div class="row my-5 mx-3">
								<div class="col-md-9  p-4 shadow-sm rounded-5" style="background-color:#f7f7f7;">
									<form
										on:submit={async () => {
											await Swal.fire({
												title: 'Are you sure?',
												text: "You won't be able to revert this!",
												icon: 'warning',
												confirmButtonText: 'Yes, cancel it!',
												showCancelButton: true
											}).then(async () => {
												await cancelRequest(res.id);
											});
										}}
									>
										<div class="row p-3 border-bottom">
											<div class="col border-right"><h2>Reservation {i + 1}</h2></div>
										</div>
										<div class="row p-3 border-bottom">
											<div class="col">
												<h3>Match</h3>
											</div>
											<div class="col">
												<h4>{res.match.homeTeam} VS. {res.match.awayTeam}</h4>
											</div>
										</div>
										<div class="row p-3 border-bottom">
											<div class="col">
												<h3>Stadium</h3>
											</div>
											<div class="col">
												<h4>{res.match.stadium}</h4>
											</div>
										</div>
										<div class="row p-3 border-bottom">
											<div class="col">
												<h3>Time</h3>
											</div>
											<div class="col">
												<h4>{new Date(res.match.time)}</h4>
											</div>
										</div>
										<div class="row p-3">
											<div class="col">
												<button class="btn " style="font-size: 1.2rem;" type="submit"
													>Cancel Reservation</button
												>
											</div>
										</div>
									</form>
								</div>
							</div>
						{/each}
					</div>
				</div>
			</div>
		</div>
	</div>
</div>

<style>
	#profile h4 {
		color: #5e5e5e;
	}
	.form-outline input {
		background-color: white;
		font-size: 1.5rem;
	}
</style>



function Redeem() {
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, redeem it!'
    }).then((result) => {
        if (result.value) {
            swal(
                'Date: 20/05/2018',
                'Your coupon has been redeemed!',
                'success'
            )

        }
    })
    
}

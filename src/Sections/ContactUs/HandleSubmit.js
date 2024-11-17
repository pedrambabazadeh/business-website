const handleSubmit = async (values, { setSubmitting, setErrors }) => {
    try {
      const response = await fetch('./api/contact_form/submit', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          ...values,
          createdOn: new Date().toISOString()
        })
      });

      if (!response.ok) {
        const errorData = await response.json();
        setErrors(errorData.errors);
        throw new Error('Form submission failed');
      }

      const responseData = await response.json();
      console.log('Form submitted successfully:', responseData);
    } catch (error) {
      console.error('Submission error:', error);
    } finally {
      setSubmitting(false);
    }
  };

  export default handleSubmit
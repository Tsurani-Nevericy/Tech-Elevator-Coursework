# !!! DO NOT CHANGE THESE LINES !!!
# You could accidentally wipe your whole drive
rm -rf ~/playground
mkdir ~/playground
cd ~/playground
# !!! DO NOT CHANGE THE LINES ABOVE !!!

# create a new directory called 'usa'
mkdir usa
# create a new directory called 'canada'
mkdir canada
# change your working directory to the 'usa' directory
cd usa
# create a new directory called 'ohio'
mkdir ohio
# create a new directory called 'pennsylvania'
mkdir pennsylvania
# create a new directory called 'michigan'
mkdir michigan
# change your working directory to the 'canada' directory
cd ../canada
# create a new directory called 'quebec'
mkdir quebec
# create a new directory called 'british columbia'
mkdir british\ columbia
# change your working directory to the 'ohio' directory
cd ../usa/ohio
# create a new directory called 'cuyahoga'
mkdir cuyahoga
# create a new directory called 'hamilton'
mkdir hamilton
# create a new directory called 'franklin'
mkdir franklin
# change your working directory to the 'pennsylvania' directory
cd ../pennsylvania
# create a new directory called 'allegheny'
mkdir allegheny
# change your working directory to the 'michigan' directory
cd ../michigan
# create a new directory called 'wayne'
mkdir wayne
# change your working directory to the 'cuyahoga' directory
cd ../ohio/cuyahoga
# create a new file in the working directory called 'cleveland.txt'
touch cleveland.txt
# create a new file in the working directory called 'cincinnati.txt'
touch cincinnati.txt
# change your working directory to the 'hamilton' directory
cd ../hamilton
# move the file called 'cincinnati.txt' from the 'cuyahoga' directory
# to the 'hamilton' directory
cd ../cuyahoga
mv cincinnati.txt ../hamilton/
# copy the file from the 'hamilton' directory called 'cincinnati.txt' into 
# the 'franklin' directory and call it 'columbus.txt'
cd ../hamilton
cp cincinnati.txt ../franklin/columbus.txt
# change your working directory to the 'allegheny' directory
cd ../../pennsylvania/allegheny
# create a new file in the working directory called 'pittsburgh.txt'
touch pittsburgh.txt
# create a new file in the wayne directory called 'detroit.txt'
cd ../../michigan/wayne
touch detroit.txt
# change your working directory to the 'quebec' directory
cd ../../../canada/quebec
# create a new file in the working directory called 'montreal.txt'
touch montreal.txt
# create a new file in the working directory called 'quebec-city.txt'
touch quebec-city.txt
# change your working directory to the 'british columbia' directory
cd ../british\ columbia
# create a new file in the working directory called 'vancouver.txt'
touch vancouver.txt
# create a new file in the working directory called 'prince-george.txt'
touch prince-george.txt
import 'dart:io';

import 'package:base_repository_bya2/export.dart';

class PaymentRepository extends BaseRepository {
  PaymentRepository()
      : super(repositoryDetails: RepositoryDetails(tokenNeeded: false));

  Future<String> getPaymentDetails({required File file,required String name}) async {
    return get(RequestInput(
      body: CustomMultipart.parseBody(
       {
         "file1":file,
         "anotherFile":name
       }
      ),
      url: "URL",
      parseJson: (response) {
        return response["data"]["PaymentDetails"];
      },
    ));
  }
}
